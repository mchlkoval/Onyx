import React, { Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { Menu } from 'semantic-ui-react';
import { NavLink } from 'react-router-dom';

const ManagerNavBar = () => {
    return (
        <Fragment>
            <Menu.Item name="Dashboard" as={NavLink} to="/overview" /> 
            <Menu.Item name="Billing" as={NavLink} to="/billing" /> 
            <Menu.Item name="Athletes" as={NavLink} to="/athletes" />
            <Menu.Item name="Coaches" as={NavLink} to="/coaches"/>
            <Menu.Item name="Teams" as={NavLink} to="/teams"/>
            <Menu.Item name="Memberships" as={NavLink} to="/membership"/>
            <Menu.Item name="Profile" as={NavLink} to="/profile"/>
        </Fragment>
    )
}

export default observer(ManagerNavBar);
