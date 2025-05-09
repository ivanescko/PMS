import { BaseQueryFn } from "@reduxjs/toolkit/query";
import { AxiosError, AxiosResponse } from "axios";

import { axiosInstance } from "./axiosInstance";

interface IBaseQueryApi {
    url: string;
    method?: "GET" | "POST" | "PUT" | "DELETE";
    body?: unknown;
    params?: Record<string, unknown>;
}

export interface IQueryError {
    statusCode: number;
    title: string;
    detail: {
        [key: string]: string[] | number[];
    };
}

function isQueryError(error: unknown): error is IQueryError {
    return (
        typeof error === "object" &&
        error !== null &&
        "statusCode" in error &&
        typeof error.statusCode === "number" &&
        "title" in error &&
        typeof error.title === "string" &&
        "detail" in error &&
        typeof error.detail === "object" &&
        error.detail !== null
    );
}

export const baseQueryInstance: BaseQueryFn<
    IBaseQueryApi,
    unknown,
    IQueryError
> = async ({ url, method = "GET", body, params }) => {
    try {
        const response: AxiosResponse = await axiosInstance({
            url,
            method,
            data: method !== "GET" ? body : undefined,
            params: method === "GET" ? params : undefined,
        });

        return { data: response.data };
    } catch (error) {
        const typedError = error as AxiosError<IQueryError>;

        if (typedError.response && isQueryError(typedError.response.data)) {
            return {
                error: {
                    statusCode: typedError.response.status,
                    title: typedError.response.data.title,
                    detail: typedError.response.data.detail,
                },
            };
        } else {
            return {
                error: {
                    statusCode: typedError.response?.status || 500,
                    title: typedError.response?.data?.title || "Unknown error",
                    detail: typedError.response?.data?.detail || {},
                },
            };
        }
    }
};
