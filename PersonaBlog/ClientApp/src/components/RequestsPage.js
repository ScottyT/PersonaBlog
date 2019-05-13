import React from 'react';
import { Redirect, withRouter } from 'react-router-dom';
import { withAuth } from '@okta/okta-react';

class RequestsPage extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			subject: '',
			content: '',
			acceptRequest: false,
			submitted: false
		};

		this.handleSubjectChange = this.handleSubjectChange.bind(this);
		this.handleContentChange = this.handleContentChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
	}

	handleSubjectChange(e) {
		this.setState({ subject: e.target.value });
	}

	handleContentChange(e) {
		this.setState({ content: e.target.value });
	}

	handleSubmit(e) {
		e.preventDefault();
		fetch('/api/requests', {
			body: JSON.stringify(this.state),
			cache: 'no-cache',
			headers: {
				'content-type': 'application/json',
				Authorization: 'Bearer ' + this.props.auth.getAccessToken()
			},
			method: 'POST'
		})
			.then(rsp => {
				if (rsp.status === 201) {
					this.props.history.push('/profile');
				}
			})
			.catch(err => {
				console.log(err);
			})
	}

	render() {
		if (this.state.submitted === true) {
			return <Redirect to="/profile" />;
		}
		return (
			<form onSubmit={this.handleSubmit}>
				<div className="form-group">
					<label>Subject:</label>
					<input
						id="subject" type="text"
						value={this.state.subject}
						onChange={this.handleSubjectChange} />
				</div>
				<div className="form-group">
					<label>Content:</label>
					<textarea
						id="content"
						cols="100"
						rows="10"
						value={this.state.content}
						onChange={this.handleContentChange} />
				</div>
				<div className="form-actions">
					<input className="btn btn-primary" id="submit" type="submit" value="Submit Request" />
				</div>
			</form>)
	}
}
export default withAuth(withRouter(RequestsPage));