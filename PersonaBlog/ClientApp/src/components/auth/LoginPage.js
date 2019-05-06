import React from 'react';
import { Redirect } from 'react-router-dom';
import OktaAuth from '@okta/okta-auth-js';
import { withAuth } from '@okta/okta-react';

export default withAuth(class LoginPage extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			sessionToken: null,
			error: null,
			username: '',
			password: ''
		};
		this.oktaAuth = new OktaAuth({ url: props.url });


		this.handleSubmit = this.handleSubmit.bind(this);

		this.handleUsernameChange = this.handleUsernameChange.bind(this);
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

	
	handleUsernameChange(e) {
		this.setState({ username: e.target.value });
	}
	handlePasswordChange(e) {
		this.setState({ password: e.target.value });
	}

	handleSubmit(e) {
		e.preventDefault();
		this.oktaAuth.signIn({
			username: this.state.username,
			password: this.state.password
		}).then(res => {
			this.setState({ sessionToken: res.sessionToken });
		})
			.catch(err => {
				this.setState({ error: err.message });
				console.log(err.statusCode + 'error', err);
			});
	}

	render() {
		if (this.state.sessionToken) {
			this.props.auth.redirect({ sessionToken: this.state.sessionToken });
			return null;
		}

		const errorMessage = this.state.error ?
			<span className="error-message text-danger">{this.state.error}</span> :
			null;

		return (
			<form onSubmit={this.handleSubmit} className="registration">
				{errorMessage}
				<div className="form-group">
					<label htmlFor="username">Username:</label>
					<input type="text" className="form-control" id="username" value={this.state.username}
						onChange={this.handleUsernameChange} />
				</div>

				<div className="form-group">
					<label htmlFor="password">Password:</label>
					<input type="password" className="form-control" id="password" value={this.state.password}
						onChange={this.handlePasswordChange} />
				</div>
				<div className="form-actions">
					<input type="submit" id="submit" className="btn btn-primary" value="Register" />
				</div>
			</form>
		);
	}

});