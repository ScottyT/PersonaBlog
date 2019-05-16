import React from 'react';
import { withAuth } from '@okta/okta-react';

import './Request.css';
import Request from './Request';

export default withAuth(class RequestsListing extends React.Component {
	constructor(props) {
		super(props);
		this.state = { requests: [] }
	}

	async getRequests() {
		fetch('/api/requests/GetRequests', {
			headers: {
				Authorization: 'Bearer ' + this.props.auth.getAccessToken()
			}
		})
			.then(rsp => rsp.json())
			.then(data => {
				this.setState({ requests: data });
			})
			.catch(err => {
				console.log(err);
			});
	}
	componentDidMount() {
		this.getRequests();
	}

	render() {
		return (
			<ul className="request-list row">
				{this.state.requests.map(request =>
					<Request key={request.id}
						id={request.id}
						request={request}
						/>)}
			</ul>)
	}
})