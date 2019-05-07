import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { withAuth } from '@okta/okta-react';
import './NavMenu.css';

export default withAuth(class NavMenu extends React.Component {
	constructor(props) {
		super(props);

		this.state = {
			authenticated: null,
			collapsed: null
		};
		this.toggleNavbar = this.toggleNavbar.bind(this);
		this.checkAuthentication = this.checkAuthentication.bind(this);
		this.logout = this.logout.bind(this);
		this.checkAuthentication();
	}

	toggleNavbar() {
		this.setState({
			collapsed: !this.state.collapsed
		});
	}

	async checkAuthentication() {
		const authenticated = await this.props.auth.isAuthenticated();
		if (authenticated !== this.state.authenticated) {
			this.setState({ authenticated })
		}
	}

	componentDidUpdate() {
		this.checkAuthentication();
	}

	logout() {
		this.props.auth.logout('/');
	}

	render() {
		if (this.state.authenticated === null) return null;
		const authNav = this.state.authenticated ?
			<ul className="nav navbar-nav navbar-right">
				<li className="nav-item">
					<a class="nav-link" href="javascript:void(0)" onClick={this.logout}>Logout</a>
				</li>
				<li className="nav-item"><NavLink tag={Link} className="text-dark" to="/profile">Profile</NavLink></li>
			</ul> :
			<ul className="nav navbar-nav navbar-right">
				<li className="nav-item"><NavLink tag={Link} className="text-dark" to="/login">Login</NavLink></li>
				<li className="nav-item"><NavLink tag={Link} className="text-dark" to="/register">Register</NavLink></li>
			</ul>
			

		return (
			<header>
				<Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
					<Container>
						<NavbarBrand tag={Link} to="/">PersonaBlog</NavbarBrand>
						<NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
						<Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
						<ul className="navbar-nav flex-grow">
							<NavItem>
								<NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
							</NavItem>
							<NavItem>
								<NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
							</NavItem>
							<NavItem>
								<NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
							</NavItem>
							{authNav}
							</ul>
						</Collapse>
					</Container>
				</Navbar>
			</header>
		)
	}
});


//export class NavMenu extends Component {
//	static displayName = NavMenu.name;

//	constructor(props) {
//		super(props);

//		this.toggleNavbar = this.toggleNavbar.bind(this);
//		this.state = {
//			collapsed: true
//		};
//	}

//	toggleNavbar() {
//		this.setState({
//			collapsed: !this.state.collapsed
//		});
//	}

//	render() {
//		return (
//			<header>
//				<Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
//					<Container>
//						<NavbarBrand tag={Link} to="/">PersonaBlog</NavbarBrand>
//						<NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
//						<Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
//							<ul className="navbar-nav flex-grow">
//								<NavItem>
//									<NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
//								</NavItem>
//								<NavItem>
//									<NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
//								</NavItem>
//								<NavItem>
//									<NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
//								</NavItem>
//								<NavItem>
//									<NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
//								</NavItem>
//								<NavItem>
//									<NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
//								</NavItem>
//							</ul>
//						</Collapse>
//					</Container>
//				</Navbar>
//			</header>
//		);
//	}
//}
