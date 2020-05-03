import React, { Fragment, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite';
import { withRouter, RouteComponentProps, Route, Switch } from 'react-router-dom';
import { RootStoreContext } from '../../Stores/RootStore';
import ModalContainer from '../General/Modals/ModalContainer';
import { Grid } from 'semantic-ui-react';
import MainNavBar from '../Navigation/MainNavBar';
import Overview from '../Overview';
import { LoadingComponent } from '../General/Loading/LoadingComponent';
import { HomePage } from '../Home/HomePage';
import Scheduling from '../Scheduling/Scheduling';
import Memberships from '../Memberships/Memberships';
import Workouts from '../Workouts/Workouts';
import Workout from '../Workouts/Workout';

const Root : React.FC<RouteComponentProps> = ({location}) => {

    const rootContext = useContext(RootStoreContext);
    const {setAppLoaded, token, appLoaded} = rootContext.commonStore;
    const {setUser} = rootContext.userStore;

    useEffect(() => {
        console.log('token: ', token);
        if(token) {
            console.log("Setting user");
            setUser().finally(() => setAppLoaded())
        } else {
            setAppLoaded();
        }
    }, [setUser, setAppLoaded, token])

    if(!appLoaded) {
        return <LoadingComponent content="Loading Application..."/>
    }

    return (
        <Fragment>
            <ModalContainer />
            <Route exact path='/' component={HomePage}/>
            
            <Route path={'/(.+)'} render={() =>
                <Grid>
                    <Grid.Column width={2}>
                        <MainNavBar />
                    </Grid.Column>
                    <Grid.Column width={13}>
                    <Switch>
                            <Route exact path="/overview" component={Overview}/>
                            <Route path="/scheduling" component={Scheduling}/>
                            <Route path="/membership" component={Memberships} />
                            <Route exact path="/workout" component={Workouts} />
                            <Route key={location.key} path='/workout/:id' component={Workout}/>
                    </Switch>
                    </Grid.Column>
                </Grid>
            }/>
        </Fragment>
    )
}

export default withRouter(observer(Root));
