import React from 'react';
import { Link } from 'react-router-dom';

class Checkbox extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			accepted: false
		};

		this.handleSubmit = this.handleSubmit.bind(this);
	}

	handleSubmit(e) {
		//e.preventDefault();
		fetch('/api/requests/Accepted', {
			method: 'POST',
			body: JSON.stringify(this.state),
			headers: {
				'Accept': 'application/json',
				'content-type': 'application/json'
			}
		})
			.then(data => {
				this.setState({
					accepted: !this.state.accepted
				});
			})
		e.checked = !e.checked;
	}

	render() {
		return (
			<input type="checkbox" id="acceptCheck" className="form-check-input" onClick={() => this.handleSubmit(this)} />
			)
	}
}


const Request = (props) => {
	return (
		<li key={props.id} className="request col-3 card">
			<h2>{props.request.subject}</h2>
			<div>{props.request.content}</div>
			<Checkbox id={props.id} />
		</li>);
}
export default Request;