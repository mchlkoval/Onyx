import React, { Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { Menu } from 'semantic-ui-react'
import { NavLink } from 'react-router-dom'

const AtheleteNavBar = () => {
    return (
        <Fragment>
            <Menu.Item name="Dashboard" as={NavLink} to="/overview" /> 
            <Menu.Item name="Scheduling" as={NavLink} to="/scheduling" />
            <Menu.Item name="Workout" as={NavLink} to="/workout"/>
            <Menu.Item name="Membership" as={NavLink} to="/membership"/>
            <Menu.Item name="My Account" as={NavLink} to="/billing"/>
            <Menu.Item name="Shop" as={NavLink} to="/shop"/>
        </Fragment>
    )
}

export default observer(AtheleteNavBar);