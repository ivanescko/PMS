import React, { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";

import { BaseButton } from "@shared/ui/buttons";

export const LanguageSwitcher: React.FC = () => {
    const { i18n } = useTranslation();

    const [currentLanguage, setCurrentLanguage] = useState<string>("");

    useEffect(() => {
        const storedLanguage = localStorage.getItem("i18nextLng");
        if (storedLanguage) {
            setCurrentLanguage(storedLanguage);
        }
    }, [currentLanguage]);

    const handleClick = () => {
        if (currentLanguage === "ru") {
            setCurrentLanguage("en");
            i18n.changeLanguage("en");
        } else {
            setCurrentLanguage("ru");
            i18n.changeLanguage("ru");
        }
    };

    return (
        <div>
            <BaseButton onClick={handleClick}>
                {currentLanguage.toUpperCase()}
            </BaseButton>
        </div>
    );
};
