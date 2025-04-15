import { Grid, List, ListItem, ListItemText } from '@mui/material'
import React from 'react'
import ActivityList from './ActivityList'
import AcitivityDetails from './ActivityDetails'

type Props = {
    activities: Activity[]
}


export default function ActivityDashBoard({activities}: Props) {
    return (
        <Grid container mt={12} spacing={3}>
            <Grid size={7}>
                <ActivityList activities={activities}></ActivityList>
            </Grid>
            <Grid size={5}>
                {activities [0] && <AcitivityDetails activity={activities[0]} />}
            </Grid>
        </Grid>
    )
}
