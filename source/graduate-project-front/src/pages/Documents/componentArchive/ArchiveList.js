import "./ArchiveList.css"

function ArchiveList({ listArchive, onArchiveClick }) {
    const handleArchiveClick = (keyNote) => {
        onArchiveClick(keyNote);
    };

    return (
        <div className='mt-3 archive-custom'>
            <table>
                <tbody>
                    {listArchive.map((archive, index) => (
                        <tr key={index} onClick={() => handleArchiveClick(archive.keyNote)} className="cursor-pointer transition duration-300 ease-in-out hover:bg-gray-200" style={{ borderBottom: '1px solid #ccc' }}>
                            <td>{archive.name}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default ArchiveList;
