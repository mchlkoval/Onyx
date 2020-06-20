import React, { useContext, Fragment } from 'react'
import { RootStoreContext } from '../../../Stores/RootStore';
import { Segment, Header, Button } from 'semantic-ui-react';
import { Formik } from 'formik';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';

interface IProps {
    id: string,
    name: string
}

const MessageAthleteModal : React.FC<IProps> = ({id, name}) => {

    const rootStore = useContext(RootStoreContext);
    const {messageAthlete} = rootStore.athleteStore;
    const {closeModal} = rootStore.modalStore;
    const {user} = rootStore.userStore;

    const handleFormSubmit = (values : any) => {
        messageAthlete({id: user!.id, message: values.message}).finally(() => {
            closeModal();
        });
        
    }

    return (
        <Segment clearing>
            <Header as="h3">Message {name}</Header>
            <Formik initialValues={{message: ""}} onSubmit={(values) => handleFormSubmit(values)}
                render= {
                    ({values, handleChange, handleSubmit}) => (
                        <Form onSubmit={handleSubmit}>
                            <Fragment key="messageAthleteForm">
                                <Form.Row>
                                    <Form.Group as={Col}>
                                        <Form.Label>Message</Form.Label>
                                        <Form.Control as="textarea" rows={10} onChange={handleChange} name="message" value={values.message}/>
                                    </Form.Group>
                                </Form.Row>
                                <Form.Row>
                                    <Form.Group as={Col} controlId='04'>
                                        <Button content="Create" floated='right' type="submit" positive />
                                        <Button content="Cancel" floated='left' type="button" negative onClick={closeModal}/>
                                    </Form.Group>
                                </Form.Row>
                            </Fragment>
                        </Form>
                    )
                }
            />
        </Segment>
    )
}

export default MessageAthleteModal
