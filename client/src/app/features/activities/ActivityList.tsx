import { Box } from '@mui/material';
import React from 'react'
import ActivityCard from './ActivityCard';

type Props = {
    activities: Activity[];
}


export default function ActivityList({activities}: Props) {
  return (
    <Box sx={{display: "flex", flexDirection: "column", gap: 3}}>
        {activities.map(act => (
            <ActivityCard key={act.id} activity={act}/>
        ))}
    </Box>
  )
}
