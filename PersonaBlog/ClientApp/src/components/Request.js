import React from 'react';
import { Link } from 'react-router-dom';

const Request = (props) => {
	return (
		<li key={props.id} className="request col-3 card">
			<h2>{props.request.subject}</h2>
			<div>{props.request.content}</div>
		</li>);
}
export default Request;