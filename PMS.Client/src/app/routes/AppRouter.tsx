import React, { Suspense } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

const MainPage = React.lazy(() => import("@pages/main"));
import { Header } from "@widgets/header";

import { appRoutePath } from "@shared/routes/appRoutePath";

/**
 * Роутер приложения
 * @component
 * @example
 * // Пример использование роутера
 * <AppRouter />
 * @returns {React.FC} Роутер приложения
 */
const AppRouter: React.FC = () => {
    return (
        <BrowserRouter>
            <Header />
            <Suspense fallback={<div>Загрузка...</div>}>
                <Routes>
                    <Route path={appRoutePath.HOME} element={<MainPage />} />
                </Routes>
            </Suspense>
        </BrowserRouter>
    );
};

export default AppRouter;
