import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { MenuItem } from '@mui/material';
import { Bloodtype, Group } from '@mui/icons-material';

export default function ButtonAppBar() {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="fixed" sx={{ backgroundImage: 'linear-gradient(135deg, #182a73 0%,#218aae 69%,#20a7ac 89%)' }}>
                <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
                    <Box>
                        <MenuItem sx={{ display: "flex", gap: 2 }}>
                            <Group fontSize='large' />
                            <Typography variant='h4' fontWeight="bold">
                                React Activity
                            </Typography>
                        </MenuItem>
                    </Box>
                    <Box display={"flex"}>
                    <MenuItem sx={{
                        fontSize: "1.2rem", textTransform: "uppercase", fontWeight: "bold"
                    }
                    }>
                        Activities
                    </MenuItem>
                    <MenuItem sx={{
                        fontSize: "1.2rem", textTransform: "uppercase", fontWeight: "bold"
                    }
                    }>
                        About
                    </MenuItem>
                    <MenuItem sx={{
                        fontSize: "1.2rem", textTransform: "uppercase", fontWeight: "bold"
                    }
                    }>
                        Activity
                    </MenuItem>
                    </Box>
                    <Button size='large' variant='contained' color='warning'>Create Activity</Button>
                </Toolbar>
            </AppBar>
        </Box>
    );
}