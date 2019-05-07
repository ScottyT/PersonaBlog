import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { Security, SecureRoute, ImplicitCallback } from '@okta/okta-react';
import { render } from 'react-dom';
import { BrowserRouter, Route } from 'react-router-dom';
//import ReactDOM from 'react-dom';
import App from './App';
import config from './app.config';
import { HomePage } from './components/HomePage';
import Layout from './components/Layout';
import NavMenu from './components/NavMenu';
import RegisterPage from './components/auth/RegisterPage';
import registerServiceWorker from './registerServiceWorker';
import LoginPage from './components/auth/LoginPage';
import ProfilePage from './components/auth/ProfilePage';

//const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
//const rootElement = document.getElementById('root');

//ReactDOM.render(
//  <BrowserRouter basename={baseUrl}>
//    <App />
//  </BrowserRouter>,
//  rootElement);

//registerServiceWorker();

const onAuthRequired = ({ history }) => history.push('/login');

render(
	<BrowserRouter>
		<Security issuer={config.issuer} client_id={config.client_id} redirect_uri={config.redirect_uri} onAuthRequired={onAuthRequired}>
			<Layout>

				<Route exact path="/" component={HomePage} />
				<Route path="/register" component={RegisterPage} />
				<Route path="/login" render={() => <LoginPage baseUrl={config.url} />} />
				<Route path="/implicit/callback" component={ImplicitCallback} />
				<SecureRoute path="/profile" component={ProfilePage} />

			</Layout>
		</Security>
	</BrowserRouter>,
	document.getElementById('root')
);
registerServiceWorker();