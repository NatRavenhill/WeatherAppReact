import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <p>Login to see the weather at <a href='./weather-forecast'>Weather Forecasts</a></p>
       </div>
    );
  }
}
