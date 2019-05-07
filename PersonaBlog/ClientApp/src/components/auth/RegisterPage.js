import React from 'react';
import { Redirect } from 'react-router-dom';
import OktaAuth from '@okta/okta-auth-js';
import { withAuth } from '@okta/okta-react';

import config from '../../app.config';

export default withAuth(class RegisterPage extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			firstName: '',
			lastName: '',
			email: '',
			password: '',
			sessionToken: null,
			registered: false
		};
		this.oktaAuth = new OktaAuth({ url: config.url });
		this.checkAuthentication = this.checkAuthentication.bind(this);
		this.checkAuthentication();

		this.handleSubmit = this.handleSubmit.bind(this);
		this.handleFirstNameChange = this.handleFirstNameChange.bind(this);
		this.handleLastNameChange = this.handleLastNameChange.bind(this);
		this.handleEmailChange = this.handleEmailChange.bind(this);
		this.handlePasswordChange = this.handlePasswordChange.bind(this);
	}

	async checkAuthentication() {
		const sessionToken = await this.props.auth.getIdToken();
		if (sessionToken) {
			this.setState({ sessionToken });
		}
	}

	componentDidUpdate() {
		this.checkAuthentication();
	}

	handleFirstNameChange(e) {
		this.setState({ firstName: e.target.value });
	}
	handleLastNameChange(e) {
		this.setState({ lastName: e.target.value });
	}
	handleEmailChange(e) {
		this.setState({ email: e.target.value });
	}
	handlePasswordChange(e) {
		this.setState({ password: e.target.value });
	}

	handleSubmit(e) {
		e.preventDefault();
		fetch('/api/users', {
			method: 'POST',
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(this.state)
		}).then(user => {
			this.setState({ registered: true, sessionToken: user.sessionToken });
		})
			.catch(err => console.log);
	}

	render() {
		console.log(this.state.sessionToken);
		if (this.state.sessionToken) {
			this.props.auth.redirect({ sessionToken: this.state.sessionToken });
			return null;
		}

		if (this.state.registered === true) {
			return <Redirect to="/login" />
		}

		return (
			<form onSubmit={this.handleSubmit} className="registration">
				<div className="form-group">
					<label for="email">Email:</label>
					<input type="email" className="form-control" id="email" value={this.state.email}
						onChange={this.handleEmailChange} />
				</div>
				<div className="form-group">
					<label for="firstName">First Name:</label>
					<input type="text" className="form-control" id="firstName" value={this.state.firstName}
						onChange={this.handleFirstNameChange} />
				</div>
				<div className="form-group">
					<label for="lastName">Last Name:</label>
					<input type="text" className="form-control" id="lastName" value={this.state.lastName}
						onChange={this.handleLastNameChange} />
				</div>
				<div className="form-group">
					<label for="password">Password:</label>
					<input type="password" className="form-control" id="password" value={this.state.password}
						onChange={this.handlePasswordChange} />
				</div>
				<div className="form-group">
					<input type="submit" id="submit" className="btn btn-primary" value="Register" />
				</div>
			</form>
		);
	}

});