import React, { useEffect, Fragment, useContext, useState } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import {Formik} from 'formik';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedMembership } from '../../Models/Memberships/IDetailedMembership';

interface IProps {
    id: string
}

const ManageMembership : React.FC<RouteComponentProps<IProps>>= ({match, history}) => {

    const root = useContext(RootStoreContext);    
    const {loadVerboseMembership} = root.membershipStore;

    const [detail, setDetail] = useState(new DetailedMembership());
    
    useEffect(() => {
        if(match.params.id) {
            loadVerboseMembership(match.params.id).then((data) => setDetail(data));
        }
    }, [match.params.id, loadVerboseMembership])

    const handleFormSubmit = (values: any) => {
        alert(JSON.stringify(values, null, 2));
    }

    return (
        <Fragment>
            <Container>
                <Segment clearing>
                    <Header>Create Membership</Header>
                    <Formik onSubmit={handleFormSubmit} initialValues={{name: "", description: "", price: ""}} 
                    render= {
                        ({values, handleChange, handleSubmit}) => (
                            <Form onSubmit={handleSubmit}>
                                <Segment>
                                    <Button floated='right'>Add Workout</Button>
                                </Segment>
                                <Fragment>
                                    <Form.Row>
                                        <Form.Group as={Col}>
                                            <Form.Label>Name</Form.Label>
                                            <Form.Control type='text' name="name" value={values.name} onChange={handleChange} />
                                        </Form.Group>
                                        <Form.Group as={Col}>
                                            <Form.Label>Price</Form.Label>
                                            <Form.Control type='text' name="price" value={values.price} onChange={handleChange} />
                                        </Form.Group>
                                    </Form.Row>
                                    <Form.Row>
                                        <Form.Group as={Col}>
                                            <Form.Label>Description</Form.Label>
                                            <Form.Control type='text' name="description" value={values.description} onChange={handleChange} />
                                        </Form.Group>
                                    </Form.Row>
                                </Fragment>
                                    
                                )}
                                <Form.Row>
                                    <Form.Group as={Col} controlId='04'>
                                        <Button content="Create" floated='right' type="submit" positive/>
                                    </Form.Group>
                                </Form.Row>
                            </Form>
                        )
                    }/>
                </Segment>
            </Container>
        </Fragment>
    )
}

export default observer(ManageMembership)
