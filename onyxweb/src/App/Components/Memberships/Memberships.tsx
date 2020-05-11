import React, { useContext, Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { Container, Button} from 'semantic-ui-react';
import Card from 'react-bootstrap/Card'
import CardDeck from 'react-bootstrap/CardDeck'
import { Link } from 'react-router-dom';
import { RootStore, RootStoreContext } from '../../Stores/RootStore';

const Memberships : React.FC = () => {

    const root = useContext(RootStoreContext);    
    const {memberships} = root.membershipStore;

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
                            <Button as={Link} to={`/membership/${m.id}`} positive floated='right' content="View Workouts" />
                        </Card.Footer>
                    </Card>
                ))}
               </CardDeck>
                
            </Container>
        </Fragment>
    )
}

export default observer(Memberships)
