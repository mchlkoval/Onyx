import React from 'react';
import {createBrowserHistory} from 'history';
import ReactDOM from 'react-dom';
import 'react-toastify/dist/ReactToastify.min.css';
import * as serviceWorker from './serviceWorker';
import { Router } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import ScrollToTop from './App/Components/General/ScrollToTop';
import { HomePage } from './App/Components/Home/HomePage';
import 'semantic-ui-css/semantic.min.css'
import './App/Styles/general.css'
import ModalContainer from './App/Components/General/Modals/ModalContainer';

//To be used within our store
export const history = createBrowserHistory();


ReactDOM.render(
  <Router history={history}>
    <ToastContainer position="bottom-right"/>
    <ModalContainer />
    <ScrollToTop>
        <HomePage />
    </ScrollToTop>
  </Router>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
