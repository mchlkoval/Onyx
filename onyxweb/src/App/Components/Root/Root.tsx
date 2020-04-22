import React, { Fragment, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite';
import { withRouter, RouteComponentProps, Route, Switch } from 'react-router-dom';
import { RootStoreContext } from '../../Stores/RootStore';
import ModalContainer from '../General/Modals/ModalContainer';
import { Grid } from 'semantic-ui-react';
import MainNavBar from '../Navigation/MainNavBar';
import Overview from '../Overview';

const Root : React.FC<RouteComponentProps> = () => {

    const rootContext = useContext(RootStoreContext);
    const {setAppLoaded, token, appLoaded} = rootContext.commonStore;
    const {setUser} = rootContext.userStore;

    useEffect(() => {
        if(token) {
            setUser().finally(() => setAppLoaded())
        } else {
            setAppLoaded();
        }
    }, [setUser, setAppLoaded, token])

    return (
        <Fragment>
            <ModalContainer />
            <Route path={'/(.+)'} render={() =>
                <Grid>
                    <Grid.Column width={3}>
                        <MainNavBar />
                    </Grid.Column>
                    <Switch>
                        <Grid.Column width={13}>
                            <Route exact path="/overview" component={Overview}/>
                        </Grid.Column>
                    </Switch>
                </Grid>
            }/>
        </Fragment>
    )
}

export default withRouter(observer(Root));
