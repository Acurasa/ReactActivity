
import { Box, Container, CssBaseline, Typography } from "@mui/material";
import axios from "axios";
import { useState } from "react"
import ActivityDashboard from "../features/activities/ActivityDashBoard";
import NavBar from "./Navbar";
import { useQuery } from "@tanstack/react-query";

function App() {
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  const { data: activities, isPending } = useQuery(
    {
      queryKey: ['activities'],
      queryFn: async () => {
        const response = await axios.get<Activity[]>('http://localhost:5015/api/activities');
        return response.data;
      }
    }
  )

  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities!.find(x => x.id === id));
  }

  const handleCancelSelectActivity = () => {
    setSelectedActivity(undefined);
  }

  const handleOpenForm = (id?: string) => {
    if (id) handleSelectActivity(id);
    else handleCancelSelectActivity();
    setEditMode(true);
  }

  const handleFormClose = () => {
    setEditMode(false);
  }

  const handleSubmitForm = (activity: Activity) => {
    // if (activity.id) {
    //   setActivities(activities.map(x => x.id === activity.id ? activity : x))
    // } else {
    //   const newActivity = {...activity, id: activities.length.toString()}
    //   setSelectedActivity(newActivity);
    //   setActivities([...activities, newActivity])
    // }
    console.log(activity);
    setEditMode(false);
  }

  const handleDelete = (id: string) => {
    console.log(id);
  }

  return (
    <Box sx={{ bgcolor: '#eeeeee', minHeight: "100" }}>
      <CssBaseline />
      <NavBar openForm={handleOpenForm} />
      <Container maxWidth='xxl' sx={{ mt: 3 }}>
        {
          !activities || isPending ? (<Typography>Loading...</Typography>) :
            (
              <ActivityDashboard
                activities={activities}
                selectActivity={handleSelectActivity}
                cancelSelectActivity={handleCancelSelectActivity}
                selectedActivity={selectedActivity}
                editMode={editMode}
                openForm={handleOpenForm}
                closeForm={handleFormClose}
                submitForm={handleSubmitForm}
                deleteActivity={handleDelete}
              />
            )
        }

      </Container>
    </Box>

  )
}

export default App