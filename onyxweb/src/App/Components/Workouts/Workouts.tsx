import React, { useContext, Fragment, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { MembershipShoreContext } from '../../Stores/MembershipStore';
import { Container, Button} from 'semantic-ui-react';
import Card from 'react-bootstrap/Card'
import CardDeck from 'react-bootstrap/CardDeck'
import { Link } from 'react-router-dom';


const Workouts : React.FC = () => {


    const membershipStore = useContext(MembershipShoreContext);
    const {memberships, loadMemberships} = membershipStore;

    useEffect(() => {
        loadMemberships();
    }, [loadMemberships])

    return (
        <Fragment>
            <Container>
                <CardDeck>
                {memberships.map(m => (
                    <Card key={m.id}>
                        <Card.Img variant="top" src="https://via.placeholder.com/100"/>
                        <Card.Body>
                            <Card.Title>{m.name}</Card.Title>
                            <Card.Text>{m.description}</Card.Text>
                        </Card.Body>
                        <Card.Footer>
                            <Button as={Link} to={`/workout/${m.id}`} positive floated='right' content="View Workouts" />
                        </Card.Footer>
                    </Card>
                ))}
               </CardDeck>
                
            </Container>
        </Fragment>
    )
}

export default observer(Workouts)
