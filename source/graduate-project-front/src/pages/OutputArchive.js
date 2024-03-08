import axios from "axios";
import React, { useState, useEffect } from 'react';
import ArchiveList from "./ComponentArchive/ArchiveList";
import DocumentArchive from "./ComponentArchive/DocumentArchive";

function OutputArchive(){
    const [archive, setArchive] = useState([]);
    const [keyNote, setKeyNote] = useState(15);
    const [selectedYear, setSelectedYear] = useState(new Date().getFullYear());

    const handleArchiveClick = (keyNote) => {
        setKeyNote(keyNote);
    };

    const handleYearChange = (event) => {
        setSelectedYear(event.target.value);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:9902/api/Document/archive/${selectedYear}`);
                setArchive(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [selectedYear]);

    return (
        <div className="centered-content ml-4" style={{width:"30%"}}>
            <div style={{ display: 'flex', flexDirection: 'row' }}>
                <div style={{ width: '50%', marginRight: '20px' }}>
                    <div className="my-4">
                        <div className="rounded-lg overflow-hidden shadow-lg">
                            <h2>Архив {selectedYear} года</h2>
                            <label htmlFor="year">Выберите год:</label>
                            <select id="year" value={selectedYear} onChange={handleYearChange}>
                                {[...Array(20).keys()].map((_, index) => (
                                    <option key={index} value={new Date().getFullYear() - index}>{new Date().getFullYear() - index}</option>
                                ))}
                            </select>
                            <ArchiveList listArchive={archive} onArchiveClick={handleArchiveClick}  />
                        </div>
                    </div>
                </div>
                <div>
                   {keyNote != 0 && <div style={{overflowY: 'auto'}}>
                        <div className="my-4" style={{width:'1000px'}} > 
                            <div className="shadow-lg">
                                <DocumentArchive keyNote={keyNote} year={selectedYear} />
                            </div>
                        </div>
                        
                    </div>
                    } 
                </div>
            </div>
        </div>
    );
}


export default OutputArchive;
