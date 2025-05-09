/**
 * Конфигурация глобального хранилища Redux и подключения API слайсов
 *
 * @store
 * @returns {object} Конфигурированное хранилище Redux
 * @example
 * // Пример использования хранилища в компоненте
 * const store = useSelector(state => state);
 */
/*
export const appStore = configureStore({
    reducer: {
        
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(
        ),
});
*/

/**
 * Тип для глобального состояния
 * @example
 * // Пример типизации селектора для обращения к редьюсеру глобального состояния:
 * const localName = useSelector((state: RootState) => state.reducerName.PropertyName);
 * @returns Тип для глобального состояния
 */
//export type RootState = ReturnType<typeof appStore.getState>;

/**
 * Тип для диспетчера действий
 * @example
 * // Пример типизации метода dispatch:
 * const dispatch = useDispatch<AppDispatch>();
 * @returns Тип для диспетчера действий
 */
//export type AppDispatch = typeof appStore.dispatch;

//export default appStore;
