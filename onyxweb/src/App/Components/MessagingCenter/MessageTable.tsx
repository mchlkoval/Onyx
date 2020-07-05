import React, { useContext, Fragment, useState, useEffect } from 'react'
import { Athletes } from '../../Models/Athlete/Athletes'
import Table from 'react-bootstrap/Table'
import { Button, Icon } from 'semantic-ui-react';
import { handleGender } from '../../Utility/UtilityFunctions';
import { RootStoreContext } from '../../Stores/RootStore';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import { GenderType } from '../../Models/Enums/Gender';
import { ICoaches } from '../../Models/Coaches/ICoaches';

interface IProps {
    athletes? : Athletes[],
    coaches? : ICoaches[]
}

interface IMappedAthlete {
    id: string, 
    name: string, 
    gender: GenderType, 
    displayTextbox: boolean,
    message: string
}

interface IBulkMessage {
    message: string,
    allChecked: boolean
}

const MessageTable : React.FC<IProps> = ({athletes, coaches}) => {

    const rootStore = useContext(RootStoreContext);
    const {messageAthlete, messageAllAthletes} = rootStore.athleteStore;
    const {messageCoach, messageAllCoaches} = rootStore.coachStore;

    const [data, setData] = useState<Array<IMappedAthlete>>([]);
    const [bulkMessage, setBulkMessage] = useState<IBulkMessage>({message: "", allChecked: false});

    useEffect(() => {
        if(athletes !== undefined) {
            var mapped = athletes.map((athlete) => ({
                id: athlete.id,
                name: athlete.name,
                gender: athlete.gender,
                displayTextbox: false,
                message: ""
                }
            ))
    
            setData(mapped);
        }
        if(coaches !== undefined) {
            var coachesMapped = coaches.map((athlete) => ({
                id: athlete.id,
                name: athlete.name,
                gender: GenderType.Female,
                displayTextbox: false,
                message: ""
                }
            ))
    
            setData(coachesMapped);
        }
    }, [athletes, coaches])
    
    const messageAll = (m: string) => {
        var ids = data.map(x => x.id);
        if(athletes !== undefined)
            messageAllAthletes({ids: ids, message: m});
        else
            messageAllCoaches({ids: ids, message: m});
        //reset message back to blank
        setBulkMessage({...bulkMessage, message: ""});
    }

    const handleCheckAll = () => {
        setBulkMessage({message: bulkMessage.message, allChecked: !bulkMessage.allChecked});

    }

    const handleAllMessageInput = (event : any) => {
        var value = event.target.value;
        setBulkMessage({...bulkMessage, message: value});
    }

    const messageSingle = (id: string) => {

        var person = data.filter(x => x.id === id)[0];
        if(athletes !== undefined) 
            messageAthlete({id: person.id, message: person.message});
        else 
            messageCoach({id: person.id, message: person.message});
        //reset message back to blank
        setData(
            data.map(x => (x.id === person.id ? {...x, message: ""} : x))
        )
    }    

    const handleCheckSingle = (person: IMappedAthlete) => {
        var displayTextbox = !person.displayTextbox;
        setData(
            data.map(x => (x.id === person.id ? {...x, displayTextbox} : x))
        )
    }

    const handleSingleMessageInput = (event : any, athlete: IMappedAthlete) => {
        var value = event.target.value;
        setData(
            data.map(x => (x.id === athlete.id ? {...x, message: value} : x))
        )

    }

    return (
        <Fragment>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>
                        <Form.Check 
                            type="checkbox"
                            id="captureAll"
                            onClick={() => handleCheckAll()}                
                        />
                        </th>
                        <th>Name</th>
                        <th>Gender</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((athlete) => (
                        <Fragment key={`f_${athlete.id}`}>
                            <tr key={athlete.id}>
                                <td>
                                    <Form.Check 
                                        type="checkbox"
                                        id={athlete.id} 
                                        onClick={() => { handleCheckSingle(athlete) }}                
                                    />
                                </td>
                                <td>{athlete.name}</td>
                                <td>{handleGender(athlete.gender)}</td>
                                <td>
                                <Button floated="right" type="button">
                                    <Icon name="envelope" />
                                </Button>
                                </td>
                            </tr>
                            <tr className={athlete.displayTextbox ? "showMessageBox" : "hideMessageBox"} key={`x_${athlete.id}`}>
                                <td colSpan={4}>
                                    <Form.Row>
                                        <Form.Group as={Col} controlId={`s_${athlete.id}`}>
                                            <Form.Control as="textarea" 
                                                rows={3} 
                                                value={athlete.message} 
                                                onChange={(e) => handleSingleMessageInput(e, athlete)}/>
                                            <Button content="Send" floated="right" positive type="button" onClick={() => messageSingle(athlete.id)}/>
                                        </Form.Group>
                                    </Form.Row>
                                </td>
                            </tr>
                        </Fragment>
                    ))}
                </tbody>
            </Table>
            <Form.Row className={bulkMessage.allChecked ? "showMessageBox" : "hideMessageBox"}>
                <Form.Group as={Col} controlId="messageAllAthletes">
                    <Form.Label>Message All Athletes</Form.Label>
                    <Form.Control as="textarea" 
                        rows={3} 
                        value={bulkMessage.message} 
                        onChange={(e) => handleAllMessageInput(e)}
                        />
                    <Button content="Send" floated="right" positive type="button" onClick={() => messageAll(bulkMessage.message)}/>
                </Form.Group>
            </Form.Row>
        </Fragment>
    )
}

export default MessageTable
