import React from "react";

import { Test } from "@features/test";

import styles from "./MainPage.module.scss";

export const MainPage: React.FC = () => {
    return (
        <div className={styles.mainPage}>
            <Test />
        </div>
    );
};
