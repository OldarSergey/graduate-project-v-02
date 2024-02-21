import React, { useState, useEffect } from 'react';
import ReactPaginate from 'react-paginate';

function PaginationMenu({ totalPages, currentPage, onPageChange }) {

    const handlePageClick = (data) => {
        const selectedPage = data.selected + 1;
        onPageChange(selectedPage);
    };

    return (
        <div className="pagination-menu">
            <ReactPaginate
                previousLabel={'Previous'}
                nextLabel={'Next'}
                breakLabel={'...'}
                breakClassName={'break-me'}
                pageCount={totalPages}
                marginPagesDisplayed={2}
                pageRangeDisplayed={5}
                onPageChange={handlePageClick}
                containerClassName={'pagination'}
                activeClassName={'active'}
                forcePage={currentPage - 1}
            />
        </div>
    );
}

export default PaginationMenu;
