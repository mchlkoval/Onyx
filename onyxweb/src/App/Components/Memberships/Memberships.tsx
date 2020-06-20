import React, { useContext, Fragment, useEffect, useState } from 'react'
import { observer } from 'mobx-react-lite'
import { Container, Button, Segment, Header} from 'semantic-ui-react';
import Card from 'react-bootstrap/Card'
import CardDeck from 'react-bootstrap/CardDeck'
import { Link } from 'react-router-dom';
import { RootStoreContext } from '../../Stores/RootStore';
import { UserType } from '../../Models/Enums/UserType';

const Memberships : React.FC = () => {

    const root = useContext(RootStoreContext);    
    const {memberships, loadMemberships} = root.membershipStore;
    const {user} = root.userStore;

    const [isManager, setUserType] = useState(false);

    useEffect(() => {
        loadMemberships().finally(() => setUserType(user!.userType === UserType.Manager));
    }, [loadMemberships, user])

    return (
        <Fragment>
            <Container>
                <Segment>
                    <Segment clearing>
                        <Header floated='left' content={isManager ? "Manage Memberships" : "My Memberships"} />
                        {user!.userType === UserType.Manager ? <Button as={Link} to="/membership/create" floated='right' >Create</Button> : null}
                    </Segment>
                <CardDeck>
                {memberships.map(m => (
                    <Card key={m.id}>
                        <Card.Img variant="top" src="https://via.placeholder.com/100"/>
                        <Card.Body>
                            <Card.Title>{m.name}</Card.Title>
                            <Card.Text>{m.description}</Card.Text>
                        </Card.Body>
                        <Card.Footer>
                            <Button as={Link} to={`/membership/${m.id}`} positive floated='right' content={isManager ? "Edit Workouts" : "View Workouts"} />
                        </Card.Footer>
                    </Card>
                ))}
               </CardDeck>
                </Segment>
                
            </Container>
        </Fragment>
    )
}

export default observer(Memberships)
