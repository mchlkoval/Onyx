import React, { useContext } from 'react'
import { observer } from 'mobx-react-lite'
import { Menu, Sidebar, Segment } from 'semantic-ui-react'
import { NavLink } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore'
import { UserType } from '../../Models/Enums/UserType'
import AtheleteNavBar from './AtheleteNavBar'
import CoachNavBar from './CoachNavBar'
import ManagerNavBar from './ManagerNavBar'

const MainNavBar = () => {

    const store = useContext(RootStoreContext);
    const {user} = store.userStore;
    
    return (
        <Menu inverted vertical fixed="left">
            <Menu.Item header as={NavLink} exact to="/">Onyx</Menu.Item>
            {user && user.userType === UserType.Athelete && <AtheleteNavBar/>}
            {user && user.userType === UserType.Coach && <CoachNavBar />}
            {user && user.userType === UserType.Manager && <ManagerNavBar />}
        </Menu>
    )
}

export default observer(MainNavBar);