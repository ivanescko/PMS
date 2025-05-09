import React, { useState, useEffect } from "react";

interface IUser {
    userID: number;
    name: string;
}

const Test: React.FC = () => {
    const [users, setUsers] = useState<IUser[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<any>(null);

    useEffect(() => {
        const fetchUsers = async () => {
            setLoading(true);
            try {
                // Замените URL на ваш реальный адрес сервера
                const response = await fetch(
                    "http://localhost:8080/api/users",
                    {
                        method: "GET",
                        headers: {
                            "Content-Type": "application/json",
                            // Добавьте другие заголовки если нужно (например, Authorization)
                        },
                        credentials: "include", // Если нужно отправлять куки/аутентификацию
                    },
                );

                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                setUsers(data);
            } catch (err) {
                setError(err);
                console.error("Error fetching users:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchUsers();
    }, []);

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h2>Users List</h2>
            <ul>
                {users.map((user) => (
                    <li key={user.userID}>{user.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default Test;
