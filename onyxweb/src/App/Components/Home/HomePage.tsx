import React, { Fragment, useContext } from 'react'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import LoginForm from '../Forms/LoginForm'
import RegisterForm from '../Forms/RegisterForm'
import { RootStoreContext } from '../../Stores/RootStore';
import { Link } from 'react-router-dom';

export const HomePage = () => {

    const root = useContext(RootStoreContext);
    const {openModal} = root.modalStore;
    const {user, isLoggedIn} = root.userStore;


    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as='h1' inverted>
                    Onyx Gym Management
                    <Header.Subheader>
                        Winning comes standard.
                    </Header.Subheader>
                </Header>
                {isLoggedIn && user ? (
                    <Fragment>
                        <Header as='h2' inverted content={`Welcome Back to Onyx`} />
                        <Button as={Link} to='/overview' size='huge' inverted>
                            Go to Onyx!
                        </Button>
                    </Fragment>
                ) : (
                    <Fragment>
                        <Header as='h2' inverted content='Welcome to Onyx' />
                        <Button onClick={() => openModal(<LoginForm/>)} to='/login' size='huge' inverted>
                            Login
                        </Button>
                        <Button onClick={() => openModal(<RegisterForm/>)} to='/register' size='huge' inverted>
                            Register
                        </Button>
                    </Fragment>
                )}  
            </Container>
        </Segment>
    )
}
