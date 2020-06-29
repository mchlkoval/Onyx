import React, { useState, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Spinner from 'react-bootstrap/Spinner'
import { Segment } from 'semantic-ui-react'
import { RootStoreContext } from '../../Stores/RootStore'
import { Athletes } from '../../Models/Athlete/Athletes'
import { ICoaches } from '../../Models/Coaches/ICoaches'
import AthleteMessageTable from './AthleteMessageTable'
import CoachMessageTable from './CoachMessageTable'

const MessageCenter = () => {

    const rootStore = useContext(RootStoreContext);
    const {listAthletes} = rootStore.athleteStore;
    const {loadCoaches} = rootStore.coachStore;
    
    const [key, setKey] = useState('athletes');
    const [athletes, setAthletes] = useState<Array<Athletes>>([]);
    const [coaches, setCoaches] = useState<Array<ICoaches>>([]);
    const [loading, setLoading] = useState(true);


    useEffect(() => {
        var promises = Array<Promise<void>>();
        if(key === "athletes") {

            var p1 = listAthletes(true).then((data) => {
                if(data !== undefined)
                    setAthletes(data);
            });

            promises.push(p1);

        } else {
            var p2 = loadCoaches(true).then((data) => {
                if(data !== undefined)
                    setCoaches(data);
            });
            
            promises.push(p2);
        }       

        Promise.all(promises).finally(() => setLoading(false));
    }, [loadCoaches, listAthletes, key])

    if(loading) {
        return <Spinner animation="border" role="status">
            <span className="sr-only">Loading Messages...</span>
        </Spinner>
    }

    return (
        <Segment clearing>
            <Tabs fill activeKey={key} id="message-center-tab" onSelect={(k : string) => {
                console.log("setting key: ", key);
                setKey(k);
            }}>
                <Tab eventKey="athletes" title="Athletes">
                    <AthleteMessageTable athletes={athletes} />
                </Tab>
                <Tab eventKey="coaches" title="Coaches">
                    <CoachMessageTable coaches={coaches} />
                </Tab>
            </Tabs>
        </Segment>
    )
}

export default observer(MessageCenter)
