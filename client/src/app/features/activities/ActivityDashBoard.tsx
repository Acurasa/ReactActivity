import { Grid, List, ListItem, ListItemText } from '@mui/material'
import React from 'react'
import ActivityList from './ActivityList'

type Props = {
    activities: Activity[]
}


export default function ActivityDashBoard({activities}: Props) {
    return (
        <Grid container mt={12}>
            <Grid size={9}>
                <ActivityList activities={activities}></ActivityList>
            </Grid>
        </Grid>
    )
}
