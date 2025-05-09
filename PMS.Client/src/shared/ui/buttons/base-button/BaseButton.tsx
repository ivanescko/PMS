import React from "react";

import styles from "./BaseButton.module.scss";

interface IBaseButtonProps
    extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    icon?: React.ReactNode;
    iconPosition?: "left" | "right";
}

export const BaseButton: React.FC<IBaseButtonProps> = ({
    children,
    icon,
    iconPosition = "left",
    className,
    ...props
}) => {
    return (
        <button
            {...props}
            className={`${styles.baseButton} ${className || ""}`}
        >
            {icon && iconPosition === "left" && (
                <span className={styles.buttonIcon}>{icon}</span>
            )}
            <span className={styles.buttonText}>{children}</span>
            {icon && iconPosition === "right" && (
                <span className={styles.buttonIcon}>{icon}</span>
            )}
        </button>
    );
};
