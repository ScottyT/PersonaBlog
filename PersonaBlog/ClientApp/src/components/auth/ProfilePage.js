﻿import React from 'react';
import { Link } from 'react-router-dom';
import { withAuth } from '@okta/okta-react';
import RequestsListing from '../RequestsListing';
import RequestListing from '../RequestListing';

export default withAuth(class ProfilePage extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			user: null
		};
		this.getCurrentUser = this.getCurrentUser.bind(this);
	}

	async getCurrentUser() {
		this.props.auth.getUser()
			.then(user => this.setState({ user }));
	}

	componentDidMount() {
		this.getCurrentUser();
	}

	render() {
		if (!this.state.user) return null;
		return (
			<section className="user-profile" >
				<h1>{this.state.user.name}'s Submitted Sessions</h1>
				<Link to="/requests" className="btn btn-primary">Submit a Request</Link>
				
				<RequestsListing />
			</section >
		)
	}
});