import React, { useContext, Fragment, useState, useEffect } from 'react'
import { Athletes } from '../../Models/Athlete/Athletes'
import Table from 'react-bootstrap/Table'
import { Button, Icon } from 'semantic-ui-react';
import { handleGender } from '../../Utility/UtilityFunctions';
import { RootStoreContext } from '../../Stores/RootStore';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import { GenderType } from '../../Models/Enums/Gender';

interface IProps {
    athletes : Athletes[]
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

const AthleteMessageTable : React.FC<IProps> = ({athletes}) => {

    const rootStore = useContext(RootStoreContext);
    const {messageAthlete, messageAllAthletes} = rootStore.athleteStore;
    const [data, setData] = useState<Array<IMappedAthlete>>([]);
    const [bulkMessage, setBulkMessage] = useState<IBulkMessage>({message: "", allChecked: false});

    useEffect(() => {
        var mapped = athletes.map((athlete) => ({
            id: athlete.id,
            name: athlete.name,
            gender: athlete.gender,
            displayTextbox: false,
            message: ""
            }
        ))

        setData(mapped);
    }, [athletes])
    
    const bulkMessageAthletes = (m: string) => {
        var ids = data.map(x => x.id);
        messageAllAthletes({ids: ids, message: m});

        //reset message back to blank
        setBulkMessage({...bulkMessage, message: ""});
    }

    const handleCheckAllAthletes = () => {
        setBulkMessage({message: bulkMessage.message, allChecked: !bulkMessage.allChecked});

    }

    const handleAllMessageInput = (event : any) => {
        var value = event.target.value;
        setBulkMessage({...bulkMessage, message: value});
    }

    const messageSingleAthlete = (id: string) => {
        var athlete = data.filter(x => x.id === id)[0];
        messageAthlete({id: athlete.id, message: athlete.message});

        //reset message back to blank
        setData(
            data.map(x => (x.id === athlete.id ? {...x, message: ""} : x))
        )
    }    

    const handleCheckSingleAthlete = (athlete: IMappedAthlete) => {
        var displayTextbox = !athlete.displayTextbox;
        setData(
            data.map(x => (x.id === athlete.id ? {...x, displayTextbox} : x))
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
                            onClick={() => handleCheckAllAthletes()}                
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
                                        onClick={() => { handleCheckSingleAthlete(athlete) }}                
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
                                            <Button content="Send" floated="right" positive type="button" onClick={() => messageSingleAthlete(athlete.id)}/>
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
                    <Button content="Send" floated="right" positive type="button" onClick={() => bulkMessageAthletes(bulkMessage.message)}/>
                </Form.Group>
            </Form.Row>
        </Fragment>
    )
}

export default AthleteMessageTable
