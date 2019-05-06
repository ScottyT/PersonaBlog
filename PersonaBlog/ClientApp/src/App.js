//import React, { Component } from 'react';
//import { Security, SecureRoute, ImplicitCallback } from '@okta/okta-react';
//import { Route, BrowserRouter } from 'react-router-dom';
//import { Layout } from './components/Layout';
//import { HomePage } from './components/HomePage';
//import { FetchData } from './components/FetchData';
//import { Counter } from './components/Counter';

//import config from './app.config';
//import RegisterPage from './components/auth/RegisterPage';
//import ProfilePage from './components/auth/ProfilePage';
//import LoginPage from './components/auth/LoginPage';

//export default class App extends Component {
//	static displayName = App.name;

//	render() {
//		const onAuthRequired = ({ history }) => history.push('/login');
//		return (
//			<BrowserRouter>
//				<Security issuer={config.issuer}
//					client_id={config.client_id}
//					redirect_uri={config.redirect_uri}
//					onAuthRequired={onAuthRequired}>
//					<Layout>
//						<Route exact path='/' component={HomePage} />
//						<Route path="/register" component={RegisterPage} />
//						<Route path='/counter' component={Counter} />
//						<Route path='/fetch-data' component={FetchData} />
//					</Layout>
//				</Security>
//			</BrowserRouter>

//		);
//	}
//}
