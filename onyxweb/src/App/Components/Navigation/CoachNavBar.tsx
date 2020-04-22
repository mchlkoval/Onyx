import React, { Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { Menu } from 'semantic-ui-react';
import { NavLink } from 'react-router-dom';

const CoachNavBar = () => {
    return (
        <Fragment>
            <Menu.Item name="Profile" as={NavLink} to="/profile" /> 
            <Menu.Item name="Athletes" as={NavLink} to="/athletes" />
            <Menu.Item name="Teams" as={NavLink} to="/teams"/>
            <Menu.Item name="Team Performance" as={NavLink} to="/teamperformance"/>
        </Fragment>
    )
}

export default observer(CoachNavBar);
