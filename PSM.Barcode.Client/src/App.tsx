import { useEffect, useState } from 'react';
import './App.css';

//interface Forecast {
//    date: string;
//    temperatureC: number;
//    temperatureF: number;
//    summary: string;
//}
interface User {
    userId: number;
    login: string;
    firstName: string;
}

function App() {
    //const [forecasts, setForecasts] = useState<Forecast[]>();
    const [users, setUsers] = useState<User[]>();

    useEffect(() => {
        //populateWeatherData();
        populateUsersData();
    }, []);

    //const contents = forecasts === undefined
    //    ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
    //    : <table className="table table-striped" aria-labelledby="tabelLabel">
    //        <thead>
    //            <tr>
    //                <th>Date</th>
    //                <th>Temp. (C)</th>
    //                <th>Temp. (F)</th>
    //                <th>Summary</th>
    //            </tr>
    //        </thead>
    //        <tbody>
    //            {forecasts.map(forecast =>
    //                <tr key={forecast.date}>
    //                    <td>{forecast.date}</td>
    //                    <td>{forecast.temperatureC}</td>
    //                    <td>{forecast.temperatureF}</td>
    //                    <td>{forecast.summary}</td>
    //                </tr>
    //            )}
    //        </tbody>
    //    </table>;

    const contents = users === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Login</th>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                {users.map(user => <tr key={user.userId}>
                    <th>{user.userId}</th>
                    <td>{user.login}</td>
                    <td>{user.firstName}</td>
                </tr>)}
            </tbody>
        </table>
        ;

    return (
        <div>
            <h1 id="tabelLabel">Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateUsersData() {
        const response = await fetch('Users');
        const data = await response.json();
        setUsers(data);
    }
    //async function populateWeatherData() {
    //    const response = await fetch('weatherforecast');
    //    const data = await response.json();
    //    setForecasts(data);
    //}
}

export default App;