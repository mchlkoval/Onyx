import React, { Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { Menu } from 'semantic-ui-react'
import { NavLink } from 'react-router-dom'

const AtheleteNavBar = () => {
    return (
        <Fragment>
            <Menu.Item name="Profile" as={NavLink} to="/profile" /> 
            <Menu.Item name="Team" as={NavLink} to="/team" />
            <Menu.Item name="My Performance" as={NavLink} to="/performance"/>
            <Menu.Item name="Billing" as={NavLink} to="/billing"/>
        </Fragment>
    )
}

export default observer(AtheleteNavBar);