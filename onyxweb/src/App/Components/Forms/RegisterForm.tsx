import React, { useContext } from 'react'
import {Form as FinalForm, Field} from 'react-final-form'; 
import { Form, Button, Segment, Header } from 'semantic-ui-react';

import { FORM_ERROR } from 'final-form';
import { combineValidators, isRequired } from 'revalidate';
import { RootStoreContext } from '../../Stores/RootStore';
import { IUserFormValues } from '../../Models/User';
import TextInput from '../General/Inputs/TextInput';
import ErrorMessage from '../General/Inputs/ErrorMessage';

const validate = combineValidators( {
    email: isRequired("email"),
    password: isRequired("password"),
    displayName: isRequired("displayName"),
    username: isRequired('username')
})

const RegisterForm = () => {

    const root = useContext(RootStoreContext);
    const {register} = root.userStore;

    return (
           <FinalForm onSubmit={(values : IUserFormValues) => register(values).catch(error => ({
               [FORM_ERROR] : error
           }))}
           validate={validate}
           render={({handleSubmit, submitting, submitError, invalid, pristine, dirtySinceLastSubmit}) => (
               <Segment>
                    <Form onSubmit={handleSubmit} error>
                        <Header as='h2' content="Register for Reactivities" color="teal" textAlign='center'/>
                        <Field name="displayName" component={TextInput} placeholder="display name"/>
                        <Field name="username" component={TextInput} placeholder="username"/>
                        <Field name="password" type="password" component={TextInput} placeholder="password"/>
                        <Field name="email" component={TextInput} placeholder="email@email.com"/>
                        {submitError && !dirtySinceLastSubmit && 
                            <ErrorMessage error={submitError} />
                        }
                        <Button loading={submitting} disabled={(invalid && !dirtySinceLastSubmit) || pristine} color='teal' content="Register" fluid />
                    </Form>
               </Segment>
            )}
        />

    )
}

export default RegisterForm
