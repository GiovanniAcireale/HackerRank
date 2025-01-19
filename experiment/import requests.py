import requests
from bs4 import BeautifulSoup

def fetch_and_display_table(url):
    # Fetch the HTML content from the URL
    response = requests.get(url)
    response.raise_for_status()

    # Parse the HTML content using BeautifulSoup
    soup = BeautifulSoup(response.text, 'html.parser')

    # Find the table in the document
    table = soup.find('table')
    if not table:
        print("No table found in the document.")
        return

    # Initialize variables to hold the grid data
    grid = {}
    max_x, max_y = 0, 0

    # Extract table rows and process the data
    rows = table.find_all('tr')
    # print("\nTable Contents:\n")
    # print(f"{'X-Coordinate':<15} {'Symbol':<10} {'Y-Coordinate':<15}")
    # print("-" * 40)
    for row in rows[1:]:  # Skip the header row
        cells = row.find_all('td')
        if len(cells) == 3:  # Ensure the row has exactly three columns
            try:
                x = int(cells[0].get_text(strip=True))
                symbol = cells[1].get_text(strip=True)
                y = int(cells[2].get_text(strip=True))

                # Update grid and track maximum coordinates
                grid[(x, y)] = symbol
                max_x = max(max_x, x)
                max_y = max(max_y, y)
            except ValueError:
                pass  # Skip rows with invalid data

    # Create the 2D grid for display
    decoded_grid = []
    for y in range(max_y + 1):  # Rows
        row = []
        for x in range(max_x + 1):  # Columns
            row.append(grid.get((x, y), ' '))  # Use space if no symbol exists
        decoded_grid.append(row)

    # Print the decoded message
    for row in decoded_grid:
        print("".join(row))  # Combine each row into a single string for display

# URL of the Google Doc containing the data
url = "https://docs.google.com/document/d/e/2PACX-1vQGUck9HIFCyezsrBSnmENk5ieJuYwpt7YHYEzeNJkIb9OSDdx-ov2nRNReKQyey-cwJOoEKUhLmN9z/pub"

# Call the function to fetch and display the table
fetch_and_display_table(url)
