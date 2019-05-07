import React from 'react';
import { withAuth } from '@okta/okta-react';
import LoginForm from './LoginForm';
import { Redirect } from '@okta/okta-react';

export default withAuth(class LoginPage extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			authenticated: null
		};
		this.checkAuthentication = this.checkAuthentication.bind(this);
		this.checkAuthentication();
	}

	async checkAuthentication() {
		const authenticated = await this.props.auth.isAuthenticated();
		if (authenticated !== this.state.authenticated) {
			this.setState({ authenticated });
		}
	}

	componentDidUpdate() {
		this.checkAuthentication();
	}

	render() {
		if (this.state.authenticated === null) return null;
		return this.state.authenticated ?
			<Redirect to={{ pathname: '/profile' }} /> :
			<LoginForm baseUrl={this.props.baseUrl} />
	}

});