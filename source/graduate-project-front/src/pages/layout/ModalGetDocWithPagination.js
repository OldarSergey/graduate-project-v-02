import axios from "axios";
import React, { useState, useEffect } from 'react';
function ModalGetDocWithPagination({nameProcedure}){
    const [documents, setDocuments] = useState([]);
    const [documentId, setDocumentId] = useState();
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(25);

    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    const handlePrevPage = () => {
        if (pageNumber > 1) {
            setPageNumber(pageNumber - 1);
        }
    };

    const handleNextPage = () => {
        setPageNumber(pageNumber + 1);
    };

    const handlePageChange = (newPage) => {
        setPageNumber(newPage);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`{https://localhost:7252/api/Document/}${nameProcedure}/${pageNumber}/${pageSize}`);
                setDocuments(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [pageNumber, pageSize]);

    return (
        <div className="centered-content">
            <div>
                <div className="my-4">
                    <div className="rounded-lg overflow-hidden shadow-lg">
                        <ModelOutputDoc documents={documents} onDocumentClick={handleDocumentClick} />
                    </div>
                </div>
                <div>
                    <button onClick={handlePrevPage} disabled={pageNumber === 1}>Previous</button>
                    <button onClick={handleNextPage}>Next</button>
                </div>
                <div>
                    <span>Page:</span>
                    <input type="number" value={pageNumber} onChange={(e) => handlePageChange(parseInt(e.target.value))} />
                </div>
                <div className="my-4">
                    <div className="rounded-lg overflow-hidden shadow-lg">
                        <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                    </div>
                </div>
            </div>
        </div>
    );
}
export default ModalGetDocWithPagination;