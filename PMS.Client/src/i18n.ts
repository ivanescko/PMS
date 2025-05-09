import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";
import HttpBackend from "i18next-http-backend";
import { initReactI18next } from "react-i18next";

/**
 * Конфигурация локализации i18n
 */
i18n.use(HttpBackend) // Загрузка переводов из внешних файлов
    .use(LanguageDetector) // Определение языка пользователя
    .use(initReactI18next) // Интеграция с React
    .init({
        supportedLngs: ["ru", "en"], // Поддерживаемые языки
        lng: "ru", // Язык по умолчанию
        ns: ["header", "main"], // Список используемых неймспейсов
        interpolation: {
            escapeValue: false, // Отключение экранирования
        },
        backend: {
            loadPath: "/locales/{{lng}}/{{ns}}.json",
        },
    });

export default i18n;
