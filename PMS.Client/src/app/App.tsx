import React from "react";

//import { Provider } from "react-redux";

import AppRouter from "./routes/AppRouter";

import "@ant-design/v5-patch-for-react-19"; // Совместимость antd с React 19

import styles from "./App.module.scss";

/**
 * Корневой компонент приложения
 * @component
 * @example
 * <App />
 * @returns {React.FC} Корневой компонент приложения
 */
export const App: React.FC = () => {
    return (
        <div className={styles.appContainer}>
            <AppRouter />
        </div>
    );
};
