import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'

export class WeatherForecast extends Component {
    static displayName = WeatherForecast.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>State</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.applicable_date}>
                            <td>{new Date(forecast.applicable_date).toLocaleDateString()}</td>
                            <td>{forecast.weather_state_name}</td>
                            <td><img style={{ height: 100 }} src={forecast.imageLocation} /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : WeatherForecast.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component displays the weather for Belfast.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const token = await authService.getAccessToken();
        const response = await fetch('weatherforecast', {
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        });
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
        console.log(data);
    }
}
