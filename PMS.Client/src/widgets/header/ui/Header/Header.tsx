import React from "react";

import { LanguageSwitcher } from "@widgets/language-switcher";

import styles from "./Header.module.scss";

/**
 * Header
 * @component
 * @example
 * Пример использования:
 * <Header />
 * @returns {React.FC} Header
 */
export const Header: React.FC = () => {
    return (
        <header className={styles.header}>
            <span>Header</span>
            <LanguageSwitcher />
        </header>
    );
};
