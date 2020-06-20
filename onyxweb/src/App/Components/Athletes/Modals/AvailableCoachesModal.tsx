import React, { useContext, useEffect, useState } from 'react'
import { IAssignedCoach } from '../../../Models/Athlete/IDetailedAthlete'
import { RootStoreContext } from '../../../Stores/RootStore';
import Spinner from 'react-bootstrap/Spinner'
import Table from 'react-bootstrap/Table'
import { Segment, Header, Button, Icon } from 'semantic-ui-react';
import { handleGender } from '../../../Utility/UtilityFunctions';

interface IProps {
    athleteId : string
    handleSelectCoach : (coach: IAssignedCoach) => void
}

const AvailableCoachesModal : React.FC<IProps> = ({athleteId, handleSelectCoach}) => {

    const rootStore = useContext(RootStoreContext);
    const {listAvailableCoaches, handleAddingAvailableCoach} = rootStore.athleteStore

    const [loading, setLoading] = useState(true);
    const [displayCoaches, setDisplayedCoaches] = useState<Array<IAssignedCoach>>([]);

    useEffect(() => {
        if(athleteId !== undefined) {
            listAvailableCoaches(athleteId)
            .then((data) => {
                if(data !== undefined) {
                    setDisplayedCoaches(data);
                }
            }).finally(() => {
                setLoading(false)
            });
        }
    }, [listAvailableCoaches, athleteId])

    const handleAddCoachClicked = async (coach : IAssignedCoach) => {
        var indexToRemove = displayCoaches.indexOf(coach);
        setDisplayedCoaches(displayCoaches.filter((x, index) => index !== indexToRemove));
        await handleAddingAvailableCoach(coach).then(() => {
            handleSelectCoach(coach);
        })
    }

    if(loading) {
        return <Spinner animation="border" role="status">
            <span className="sr-only">Loading...</span>
        </Spinner>
    }

    return (
        <Segment clearing>
            <Header as="h3">Available Coaches</Header>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Gender</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {displayCoaches.map((coach) => (
                        <tr key={coach.id}>
                            <td>{coach.name}</td>
                            <td>{handleGender(coach.gender)}</td>
                            <td>
                            <Button floated="right" type="button" onClick={() => handleAddCoachClicked(coach)}>
                                <Icon name="user plus"/>
                            </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Segment>
    )
}

export default AvailableCoachesModal
