import React, { useContext, useEffect, useState } from 'react'
import { RootStoreContext } from '../../../Stores/RootStore';
import Table from 'react-bootstrap/Table'
import { handleGender, handleDate } from '../../../Utility/UtilityFunctions';
import { Button, Icon, Segment, Header } from 'semantic-ui-react';
import Spinner from 'react-bootstrap/Spinner'
import { IAssignedAthletes } from '../../../Models/Coaches/IDetailedCoach';

interface IProps {
    coachId: string
    handleSelectAthlete : (athlete : IAssignedAthletes) => void
}

const AvailableAthletesModal : React.FC<IProps> = ({coachId, handleSelectAthlete}) => {

    const rootStore = useContext(RootStoreContext);
    const {listAvailableStudents, handleAddingAvailableAthlete} = rootStore.coachStore;
    const [loading, setLoading] = useState(true);
    const [displayedAthletes, setDisplayedAthletes] = useState<Array<IAssignedAthletes>>([]);

    useEffect(() => {
        if(coachId !== undefined) {
            listAvailableStudents(coachId)
            .then((data) => {
                if(data !== undefined) {                
                    setDisplayedAthletes(data);
                }
            })
            .finally(() => {
                setLoading(false)
            });
        }

    }, [listAvailableStudents, coachId])


    const handleAddAthleteClicked = async (athlete: IAssignedAthletes) => {
        var indexToRemove = displayedAthletes.indexOf(athlete);
        setDisplayedAthletes(displayedAthletes.filter((x, index) => index !== indexToRemove));
        await handleAddingAvailableAthlete(athlete).then(() => {
            handleSelectAthlete(athlete);
        });
    }

    if(loading) {
        return <Spinner animation="border" role="status">
            <span className="sr-only">Loading...</span>
        </Spinner>
    }

    return (
        <Segment clearing>
            <Header as="h3">Available Athletes</Header>
            <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Gender</th>
                    <th>Date Joined</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {displayedAthletes.map((athlete, index) => (
                    <tr key={athlete.athleteId}>
                        <td>{athlete.name}</td>
                        <td>{handleGender(athlete.gender)}</td>
                        <td>{handleDate(athlete.dateJoined)}</td>
                        <td>
                        <Button floated="right" type="button" onClick={() => handleAddAthleteClicked(athlete)}>
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

export default AvailableAthletesModal
