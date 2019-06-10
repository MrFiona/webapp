﻿import React, { Component } from "react";
import { Route, Switch, Redirect } from "react-router-dom";
import "./App.css";
import NavBar from "./components/NavBar";
import Footer from "./components/Footer";

import List2 from "./components/List2";
//TODO Web Template Studio: Add routes for your new pages here.
class App extends Component {
  render() {
    return (
      <React.Fragment>
        <NavBar />
        <Switch>
          < Redirect exact path = "/" to = "/List2" />
          < Route path = "/List2" component = { List2 } />
        </Switch>
        <Footer />
      </React.Fragment>
    );
  }
}

export default App;