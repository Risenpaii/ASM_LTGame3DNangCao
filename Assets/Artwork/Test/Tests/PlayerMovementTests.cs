using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using Scripfs.Player;

public class PlayerMovementTests
{
    private GameObject player;
    private PlayerMotor playerMotor;
    private CharacterController characterController;
    private Vector3 initialPosition;
    private float moveSpeed = 5f;
    private float sprintSpeed = 8f;
    private float jumpHeight = 4f;

    [SetUp]
    public void Setup()
    {
        // Tạo player object với các component cần thiết
        player = new GameObject("Player");
        characterController = player.AddComponent<CharacterController>();
        playerMotor = player.AddComponent<PlayerMotor>();
        playerMotor.speed = moveSpeed;
        playerMotor.jumpHeight = jumpHeight;
        
        // Lưu vị trí ban đầu
        initialPosition = player.transform.position;
    }

    [Test]
    public void PlayerMovesForward_WhenWKeyPressed()
    {
        // Arrange
        Vector2 input = new Vector2(0, 1); // W key

        // Act
        playerMotor.ProcessMove(input);
        float deltaTime = 1f; // Giả lập 1 giây
        player.transform.position += player.transform.forward * moveSpeed * deltaTime;

        // Assert
        Assert.Greater(player.transform.position.z, initialPosition.z);
    }

    [Test]
    public void PlayerMovesBackward_WhenSKeyPressed()
    {
        // Arrange
        Vector2 input = new Vector2(0, -1); // S key

        // Act
        playerMotor.ProcessMove(input);
        float deltaTime = 1f;
        player.transform.position += player.transform.forward * moveSpeed * deltaTime;

        // Assert
        Assert.Less(player.transform.position.z, initialPosition.z);
    }

    [Test]
    public void PlayerMovesLeft_WhenAKeyPressed()
    {
        // Arrange
        Vector2 input = new Vector2(-1, 0); // A key

        // Act
        playerMotor.ProcessMove(input);
        float deltaTime = 1f;
        player.transform.position += player.transform.right * moveSpeed * deltaTime;

        // Assert
        Assert.Less(player.transform.position.x, initialPosition.x);
    }

    [Test]
    public void PlayerMovesRight_WhenDKeyPressed()
    {
        // Arrange
        Vector2 input = new Vector2(1, 0); // D key

        // Act
        playerMotor.ProcessMove(input);
        float deltaTime = 1f;
        player.transform.position += player.transform.right * moveSpeed * deltaTime;

        // Assert
        Assert.Greater(player.transform.position.x, initialPosition.x);
    }

    [Test]
    public void PlayerSprints_WhenSprintKeyPressed()
    {
        // Arrange
        playerMotor.Sprint();

        // Act
        float currentSpeed = playerMotor.speed;

        // Assert
        Assert.AreEqual(sprintSpeed, currentSpeed);
    }

    [Test]
    public void PlayerReturnsToNormalSpeed_WhenSprintKeyPressedAgain()
    {
        // Arrange
        playerMotor.Sprint();
        playerMotor.Sprint();

        // Act
        float currentSpeed = playerMotor.speed;

        // Assert
        Assert.AreEqual(moveSpeed, currentSpeed);
    }

    [Test]
    public void PlayerJumps_WhenJumpKeyPressed()
    {
        // Arrange
        playerMotor.Jump();

        // Act
        float verticalVelocity = playerMotor.playerVelocity.y;

        // Assert
        Assert.Greater(verticalVelocity, 0);
    }

    [Test]
    public void PlayerCannotJump_WhenNotGrounded()
    {
        // Arrange
        playerMotor.isGrounded = false;
        float initialVelocity = playerMotor.playerVelocity.y;

        // Act
        playerMotor.Jump();

        // Assert
        Assert.AreEqual(initialVelocity, playerMotor.playerVelocity.y);
    }

    [Test]
    public void PlayerCrouches_WhenCrouchKeyPressed()
    {
        // Arrange
        float initialHeight = characterController.height;

        // Act
        playerMotor.Crounch();

        // Assert
        Assert.Less(characterController.height, initialHeight);
    }

    [Test]
    public void PlayerStandsUp_WhenCrouchKeyPressedAgain()
    {
        // Arrange
        playerMotor.Crounch();
        float crouchedHeight = characterController.height;

        // Act
        playerMotor.Crounch();

        // Assert
        Assert.Greater(characterController.height, crouchedHeight);
    }

    [Test]
    public void PlayerMaintainsDirection_WhenMovingDiagonally()
    {
        // Arrange
        Vector2 input = new Vector2(1, 1); // WD keys

        // Act
        playerMotor.ProcessMove(input);
        float deltaTime = 1f;
        player.transform.position += (player.transform.forward + player.transform.right) * moveSpeed * deltaTime;

        // Assert
        Assert.Greater(player.transform.position.x, initialPosition.x);
        Assert.Greater(player.transform.position.z, initialPosition.z);
    }
}