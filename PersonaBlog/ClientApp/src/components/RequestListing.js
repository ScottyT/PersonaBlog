import React, { Component } from 'react';

export default class RequestListing extends Component {
	constructor(props) {
		super(props);
		this.state = {
			requests: []
		};

		
	}

	componentDidMount() {
		fetch('/api/requests')
			.then(response => response.json())
			.then(data => {
				this.setState({ requests: data });
			});
	}

	static renderRequests(requests) {
		return (
			<ul className="request-list row">
				{requests.map(request =>
					<li className="col-3" key={request.id}>Subject: {request.subject}<br/>
						Content: {request.content}
					</li>)}
			</ul>)
	}

	render() {
		var contents = RequestListing.renderRequests(this.state.requests);

		return (
			<div>{contents}</div>
		);
	}
}