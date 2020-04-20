import React, { Fragment, useContext } from 'react'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import LoginForm from '../Forms/LoginForm'
import RegisterForm from '../Forms/RegisterForm'
import { RootStoreContext } from '../../Stores/RootStore';

export const HomePage = () => {

    const root = useContext(RootStoreContext);
    const {openModal} = root.modalStore;


    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as='h1' inverted>
                    Onyx Gym Management
                    <Header.Subheader>
                        Winning comes standard.
                    </Header.Subheader>
                </Header>
                <Fragment>
                <Button onClick={() => openModal(<LoginForm/>)} to='/login' size='huge' inverted>
                    Login
                </Button>
                <Button onClick={() => openModal(<RegisterForm/>)} to='/register' size='huge' inverted>
                    Register
                </Button>
                </Fragment>
            </Container>
        </Segment>
    )
}
